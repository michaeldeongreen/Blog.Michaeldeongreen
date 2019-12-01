import { Component, OnInit, Pipe } from '@angular/core';
import { HttpService } from '../http.service';
import { ActivatedRoute } from '@angular/router';
import { DomSanitizer, SafeHtml } from '@angular/platform-browser';

@Component({
  selector: 'app-preview',
  templateUrl: './preview.component.html',
  styleUrls: ['./preview.component.css']
})

@Pipe({ name: 'SafeHtml' })
export class PreviewComponent implements OnInit {
    html: SafeHtml;
    parameter: string;
    item: any = {};
    busy: boolean = true;

    constructor(private httpService: HttpService,
        private route: ActivatedRoute,
        private domSanitizer: DomSanitizer) { }

    ngOnInit() {
        this.parameter = this.route.snapshot.params['title'];
        this.getPost(this.parameter);
        this.getHtml(this.parameter);
    }

    getPost(title: string) {
        this.httpService.getPostPreview(title)
            .subscribe(data => {
                // get pager object from service
                this.item = data;
            },
            err => {
                console.log("Error while retrieving post preview");
            }
        );
    }

    getHtml(title: string) {
        this.httpService.getPostPreviewHtml(title)
            .subscribe(data => {
                // get pager object from service
                this.html = this.domSanitizer.bypassSecurityTrustHtml(data);
                console.log(this.html);
                this.busy = false;
            },
            err => {
                console.log("Error while retrieving post preview html");
            }
        );
    }

}
